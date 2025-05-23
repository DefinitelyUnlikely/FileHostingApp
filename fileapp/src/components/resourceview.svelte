<script lang="ts">
	import type { Folder } from '$lib/models';

	let { folders = [] }: { folders: Folder[] } = $props();
</script>

<div class="folders">
	{#each folders as folder}
		<div class="folder">{folder.name}</div>
	{/each}
</div>

<style>
</style>
