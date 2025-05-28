<script lang="ts">
	import type { Folder, FileMetadata } from '$lib/models';

	let { folders = [], files = [] }: { folders: Folder[]; files: FileMetadata[] } = $props();
</script>

<div class="folders"></div>
<br />
<div class="files"></div>

<style>
</style>
