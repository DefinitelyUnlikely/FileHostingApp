<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { API_BASE_URL } from '$lib/config';
	import { isXModalVisible } from '$lib/shared.svelte';
	import { RefreshToken } from '../../stores/auth';
	import { getCookie } from '../../utils/cookies';

	let fileName = $state('');
	let extension = $state('');
	let message = $state('');

	let { id } = $props();

	async function RenameFile(event: SubmitEvent, id: String) {
		event.preventDefault();
		let response = await fetch(API_BASE_URL + '/file/' + id, {
			method: 'PATCH',
			headers: {
				authorization: 'Bearer ' + getCookie('token'),
				'content-type': 'application/json'
			},
			body: JSON.stringify({
				id: id,
				name: fileName,
				extension: extension
			})
		});

		if (!response.ok) {
			if (!RefreshToken()) {
				message = 'Unauthorized. If the problem persists, please log back in.';
				return;
			}

			response = await fetch(API_BASE_URL + '/file/' + id, {
				method: 'PATCH',
				headers: {
					authorization: 'Bearer ' + getCookie('token'),
					'content-type': 'application/json'
				},
				body: JSON.stringify({
					id: id,
					name: fileName,
					extension: extension
				})
			});

			if (!response.ok) {
				message = 'File was not updated';
				return;
			}
		}

		message = 'file has been updated';
		invalidateAll();
	}
</script>

<div class="file-modal">
	<h3>Rename File</h3>
	<p>{message}</p>
	<form
		onsubmit={(event) => {
			RenameFile(event, id);
		}}
	>
		<label for="file-name">File name</label>
		<input id="file-name" name="file-name" type="text" bind:value={fileName} />
		<label for="file-extension">File Extension</label>
		<input id="file-extension" name="file-extension" type="text" bind:value={extension} />
		<button type="submit">Rename</button>
	</form>
	<button class="close" onclick={() => (isXModalVisible['edit' + id] = false)}>X</button>
</div>

<style>
	.file-modal {
		z-index: 100;
		position: absolute;
		width: 90%;
		height: 40%;
		top: 50%;
		left: 50%;
		transform: translate(-50%, -50%);
		background-color: #ebebebff;
		border: 2px solid #d6d6d6ff;
		border-radius: 10px;

		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	p {
		text-align: center;
	}
	.file-modal form {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	button {
		--color: #0e79b2ff;
		font-family: inherit;
		width: 6em;
		height: 2.6em;
		line-height: 2.5em;
		overflow: hidden;
		cursor: pointer;
		margin: 20px;
		font-size: 17px;
		z-index: 1;
		color: var(--color);
		border: 2px solid var(--color);
		border-radius: 6px;
		position: relative;
	}

	button::before {
		position: absolute;
		content: '';
		background: var(--color);
		width: 150px;
		height: 200px;
		z-index: -1;
		border-radius: 50%;
	}

	button:hover {
		color: white;
	}

	button:before {
		top: 100%;
		left: 100%;
		transition: 0.3s all;
	}

	button:hover::before {
		top: -30px;
		left: -30px;
	}

	.close {
		background-color: #ee6c4dff;
		color: white;
		border: none;
		height: 2.6rem;
		line-height: 2.6rem;
		width: 2.6rem;
		margin-top: auto;
		margin-left: auto;
	}
</style>
