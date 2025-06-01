<script lang="ts">
	import { invalidateAll } from '$app/navigation';
	import { API_BASE_URL } from '$lib/config';
	import { isXModalVisible } from '$lib/shared.svelte';
	import { getCookie } from '../../utils/cookies';

	let message = $state('');

	let { folderId } = $props();

	async function deleteFolder() {
		if (folderId == undefined) {
			message =
				'Sorry, you cannot delete the root directory. If you are not trying to delete the root directory, something has gone wrong';
		}

		let response = await fetch(API_BASE_URL + '/' + folderId, {
			method: 'PATCH',
			headers: {
				authorization: 'Bearer ' + getCookie('token'),
				'content-type': 'application/json'
			}
		});

		if (!response.ok) {
			message = 'Folder could not be deleted, make sure it is empty first.';
			return;
		}

		message = 'folder deleted';
		invalidateAll();
	}
</script>

<div class="folder-modal">
	<h3>Delete Folder</h3>
	<p>{message}</p>
	<p>Are you sure you want to delete this folder? (You cannot delete folders with children)</p>
	<button class="delete" onclick={deleteFolder}>Delete</button>
	<button class="close" onclick={() => (isXModalVisible.deleteFolder = false)}>X</button>
</div>

<style>
	.folder-modal {
		z-index: 100;
		position: fixed;
		width: 90%;
		height: 35%;
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

	.delete {
		background-color: #ee6c4dff;
		color: white;
		border: none;
		height: 2.6rem;
		line-height: 2.6rem;
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
