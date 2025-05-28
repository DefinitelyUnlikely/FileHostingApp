<script lang="ts">
	import type { Folder, FileMetadata } from '$lib/models';

	let { folders = [], files = [] }: { folders: Folder[]; files: FileMetadata[] } = $props();
</script>

<div class="folders">
	{#each folders as folder}
		<div class="folder">
			{folder.name}
		</div>
	{/each}
</div>

<br />
<div class="files"></div>

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
</style>
