<script lang="ts">
	import type { Folder, FileMetadata } from '$lib/models';
	import type { PageData } from '../routes/$types';

	export let resources: PageData;

	function formatDateTime(dateString: string): string {
		const date = new Date(dateString);
		return date.toISOString().slice(0, 16).replace('T', ' ');
	}
</script>

<h2>Folders</h2>
<div class="folders">
	<div class="folder-headers"></div>
	{#each resources.response.subFolders as folder}
		<div class="folder" id={folder.id}>
			{folder.name}
		</div>
	{/each}
</div>

<br />

<h2>Files</h2>
<div class="files">
	<div class="file-headers">
		<h4>Name</h4>
		<h4>Extension</h4>
		<h4 class="created">Created</h4>
		<h4 class="updated">Last Modified</h4>
	</div>
	{#each resources.response.files as file}
		<div class="file" id={file.id}>
			<div>{file.name}</div>
			<div>{file.extension}</div>
			<div class="created">{formatDateTime(file.createdAt)}</div>
			<div class="updated">{formatDateTime(file.updatedAt)}</div>
		</div>
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
			grid-template-columns: 2fr 2fr 2fr 2fr;
			width: 100%;
			justify-items: center;
		}

		.file {
			display: grid;
			grid-template-columns: 2fr 2fr 2fr 2fr;
			width: 100%;
			justify-items: center;
			margin: 2px;
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
			grid-template-columns: 2fr 2fr;
			width: 100%;
			justify-items: center;
		}

		.file {
			display: grid;
			grid-template-columns: 2fr 2fr;
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
	}
</style>
