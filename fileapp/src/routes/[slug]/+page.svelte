<script lang="ts">
	import type { PageData } from './$types';
	import { goto } from '$app/navigation';
	import { isLoggedIn } from '../../stores/auth';
	import { onMount } from 'svelte';
	import ModalFolderNew from '../../components/modal/modalFolderNew.svelte';
	import ModalUpload from '../../components/modal/modalUpload.svelte';
	import Drive from '../../components/drive.svelte';
	import { isXModalVisible } from '$lib/shared.svelte';
	import ModalFolderRename from '../../components/modal/modalFolderRename.svelte';
	import ModalFolderDelete from '../../components/modal/modalFolderDelete.svelte';
	import ModalFileDownload from '../../components/modal/modalFileDownload.svelte';
	import ModalFileDelete from '../../components/modal/modalFileDelete.svelte';
	import ModalFileEdit from '../../components/modal/modalFileEdit.svelte';

	export let data: PageData;

	onMount(() => {
		if (!$isLoggedIn) {
			goto('/login');
		}
	});

	function goBack() {
		window.history.back();
	}
</script>

<svelte:head>
	<title>Sunset Drive &#x2022 {data.response.name}</title>
</svelte:head>

<button onclick={goBack}>&lt;- Back</button>
{#if $isLoggedIn}<Drive props={data} />{/if}

{#if isXModalVisible.folder}<ModalFolderNew folderId={data.slug} />{/if}
{#if isXModalVisible.upload}<ModalUpload folderId={data.slug} />{/if}

<!-- {#if isXModalVisible.download}<ModalFileDownload fileId={data.slug} />{/if}
{#if isXModalVisible.deleteFile}<ModalFileDelete fileId={data.slug} />{/if}
{#if isXModalVisible.editFile}<ModalFileEdit fileId={data.slug} />{/if} -->

<style>
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
</style>
