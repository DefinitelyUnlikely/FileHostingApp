<script lang="ts">
	import type { PageData } from './$types';
	import { goto } from '$app/navigation';
	import { isLoggedIn } from '../stores/auth';
	import { onMount } from 'svelte';
	import ModalFolder from '../components/modalFolder.svelte';
	import ModalUpload from '../components/modalUpload.svelte';
	import Drive from '../components/drive.svelte';
	import { isXModalVisible } from '$lib/shared.svelte';

	export let data: PageData;

	onMount(() => {
		if (!$isLoggedIn) {
			goto('/login');
		}
	});
</script>

<svelte:head>
	<title>Sunset Drive</title>
</svelte:head>

{#if $isLoggedIn}<Drive props={data} />{/if}

{#if isXModalVisible.folder}<ModalFolder />{/if}
{#if isXModalVisible.upload}<ModalUpload />{/if}

<style>
</style>
