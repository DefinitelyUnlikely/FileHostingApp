<script lang="ts">
	import type { PageData } from '../routes/$types';
	import { isXModalVisible } from '$lib/shared.svelte';
	import { goto } from '$app/navigation';

	export let resources: PageData;

	let openFolders = new Set<string>();
	let openFiles = new Set<string>();

	function formatDateTime(dateString: string): string {
		const date = new Date(dateString);
		return date.toISOString().slice(0, 16).replace('T', ' ');
	}

	function toggleFolder(folderId: string) {
		if (openFolders.has(folderId)) {
			openFolders.delete(folderId);
		} else {
			openFolders.add(folderId);
		}

		openFolders = openFolders;
	}

	function toggleFile(fileId: string) {
		if (openFiles.has(fileId)) {
			openFiles.delete(fileId);
		} else {
			openFiles.add(fileId);
		}

		openFiles = openFiles;
	}

	// We might be putting these functions
	// into the lib, but they might also do nothing more
	// than open a modal, and the functions in the modal will
	// do the rest.ss
	function openFolder(id: string) {
		goto('/' + id);
	}

	function renameFolder() {
		isXModalVisible.renameFolder = !isXModalVisible.renameFolder;
	}

	function deleteFolder() {
		isXModalVisible.deleteFolder = !isXModalVisible.deleteFolder;
	}
</script>

<h2>Folders</h2>
<div class="folders">
	<div class="folder-headers"></div>
	{#each resources.response.subFolders as folder}
		<!-- svelte-ignore a11y_click_events_have_key_events -->
		<!-- svelte-ignore a11y_no_static_element_interactions -->
		<div class="folder" id={folder.id} onclick={() => toggleFolder(folder.id)}>
			{folder.name}
		</div>
		{#if openFolders.has(folder.id)}
			<div class="folder-options">
				<!-- svelte-ignore a11y_click_events_have_key_events -->
				<!-- svelte-ignore a11y_no_static_element_interactions -->
				<div onclick={() => openFolder(folder.id)}>Open</div>
				<!-- svelte-ignore a11y_click_events_have_key_events -->
				<!-- svelte-ignore a11y_no_static_element_interactions -->
				<div onclick={renameFolder}>Rename</div>
				<!-- svelte-ignore a11y_click_events_have_key_events -->
				<!-- svelte-ignore a11y_no_static_element_interactions -->
				<div onclick={deleteFolder}>Delete</div>
			</div>
		{/if}
	{/each}
</div>

<br />

<h2>Files</h2>
<div class="files">
	{#if Object.keys(resources.response.files).length}
		<div class="file-headers">
			<h4>Name</h4>
			<h4>Extension</h4>
			<h4 class="created">Created</h4>
			<h4 class="updated">Last Modified</h4>
			<h4 class="size">Size (Bit)</h4>
			<h4 class="options">Options</h4>
		</div>
	{/if}
	{#each resources.response.files as file}
		<!-- svelte-ignore a11y_click_events_have_key_events -->
		<!-- svelte-ignore a11y_no_static_element_interactions -->
		<div class="file" id={file.id} onclick={() => toggleFile(file.id)}>
			<div>{file.name}</div>
			<div>{file.extension}</div>
			<div class="created">{formatDateTime(file.createdAt)}</div>
			<div class="updated">{formatDateTime(file.updatedAt)}</div>
			<div class="size">{file.fileSize}</div>
			<button class="options">...</button>
		</div>
		{#if openFiles.has(file.id)}
			<div class="file-options">
				<div>Download</div>
				<div>Edit</div>
				<div>Delete</div>
			</div>
		{/if}
	{/each}
</div>

<style>
	.folders {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: start;
		width: 100%;
	}

	.folder {
		z-index: 1;
		display: flex;
		justify-content: flex-start;
		align-items: center;
		width: 99%;
		margin: 0.2rem;
		--color: #0e79b2ff;
		overflow: hidden;
		cursor: pointer;
		color: var(--color);
		border: 2px solid var(--color);
		border-radius: 6px;
		position: relative;
	}

	.folder::before {
		position: absolute;
		content: '';
		background: var(--color);
		width: 100%;
		height: 100%;
		z-index: -1;
	}

	.folder:hover {
		color: white;
	}

	.folder:before {
		top: 0;
		left: 100%;
		transition: 0.3s all;
	}

	.folder:hover::before {
		top: 0;
		left: 0;
	}

	.file:hover {
		cursor: pointer;
		background-color: rgb(219, 219, 219);
	}

	.folder-options {
		margin: 1rem;
		width: 90%;
	}

	.folder-options > div:hover {
		cursor: pointer;
		background-color: #0e79b2ff;
	}

	.file-options {
		margin: 1rem;
		width: 90%;
	}

	.file-options > div:hover {
		cursor: pointer;
		background-color: rgb(219, 219, 219);
	}

	@media only screen and (min-width: 600px) {
		.files {
			display: flex;
			flex-direction: column;
			justify-content: flex-start;
			align-items: center;
			width: 100%;
		}

		.file-headers {
			display: grid;
			grid-template-columns: 2fr 2fr 2fr 2fr 2fr;
			width: 99%;
		}

		.file {
			display: grid;
			grid-template-columns: 2fr 2fr 2fr 2fr 2fr;
			width: 99%;
			margin: 2px;
		}

		.options {
			display: none;
		}

		.file-options {
			align-self: flex-start;
		}
	}

	@media only screen and (max-width: 599px) {
		.files {
			display: flex;
			flex-direction: column;
			justify-content: flex-start;
			align-items: center;
			width: 100%;
		}

		.file-headers {
			display: grid;
			grid-template-columns: 2fr 2fr 2fr;
			width: 100%;
			justify-items: center;
		}

		.file {
			display: grid;
			grid-template-columns: 2fr 2fr 2fr;
			width: 100%;
			justify-items: center;
			margin: 2px;
		}

		.created {
			display: none;
		}

		.updated {
			display: none;
		}

		.size {
			display: none;
		}

		button.options {
			border-radius: 5rem;
			border: 1px solid;
		}

		button.options:hover {
			background-color: #0e79b2ff;
			color: white;
		}

		.folder-options {
			align-self: center;
		}
	}
</style>
