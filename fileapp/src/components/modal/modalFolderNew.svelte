<script lang="ts">
	import { goto, invalidateAll } from '$app/navigation';
	import { API_BASE_URL } from '$lib/config';
	import { isXModalVisible } from '$lib/shared.svelte';
	import { getCookie } from '../../utils/cookies';

	let folderName = $state('');
	let message = $state('');

	let { folderId }: { folderId: string | undefined } = $props();

	// Consider sending the slug to these modals
	// Then we coudl reuse the modal more easily and
	// still goto the current folder (which we'll get from the slug)
	async function NewFolder(event: SubmitEvent, id: string | undefined) {
		event.preventDefault();

		let response;

		if (id == undefined) {
			response = await fetch(API_BASE_URL + '/folder', {
				method: 'POST',
				headers: {
					authorization: 'Bearer ' + getCookie('token'),
					'content-type': 'application/json'
				},
				body: JSON.stringify({
					name: folderName
				})
			});
		} else {
			response = await fetch(API_BASE_URL + '/folder/', {
				method: 'POST',
				headers: {
					authorization: 'Bearer ' + getCookie('token'),
					'content-type': 'application/json'
				},
				body: JSON.stringify({
					name: folderName,
					parentfolderid: id
				})
			});
		}

		if (!response.ok) {
			console.log('Error creating folder');
			message = 'Error when creating the folder, status code: ' + response.status.toString();
		}

		await invalidateAll();
		isXModalVisible.folder = false;
	}
</script>

<div class="folder-modal">
	<h3>Create Folder</h3>
	<p>{message}</p>
	<p>The folder will be created in the current directory</p>
	<form
		onsubmit={(event) => {
			NewFolder(event, folderId);
		}}
	>
		<label for="folder-name">Folder name</label>
		<input id="folder-name" name="folder-name" type="text" bind:value={folderName} />
		<button type="submit">Create</button>
	</form>
	<button class="close" onclick={() => (isXModalVisible.folder = false)}>X</button>
</div>

<style>
	.folder-modal {
		z-index: 100;
		position: fixed;
		width: 90%;
		height: 70%;
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
	.folder-modal form {
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
