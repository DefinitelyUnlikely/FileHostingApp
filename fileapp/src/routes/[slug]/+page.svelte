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
</script>

<svelte:head>
	<title>Sunset Drive &#x2022 {data.response.name}</title>
</svelte:head>

{#if $isLoggedIn}<Drive props={data} />{/if}

{#if isXModalVisible.folder}<ModalFolderNew folderId={data.slug} />{/if}
{#if isXModalVisible.renameFolder}<ModalFolderRename folderId={data.slug} />{/if}
{#if isXModalVisible.deleteFolder}<ModalFolderDelete folderId={data.slug} />{/if}
{#if isXModalVisible.upload}<ModalUpload folderId={data.slug} />{/if}
{#if isXModalVisible.download}<ModalFileDownload fileId={data.slug} />{/if}
{#if isXModalVisible.deleteFile}<ModalFileDelete fileId={data.slug} />{/if}
{#if isXModalVisible.editFile}<ModalFileEdit fileId={data.slug} />{/if}

<style>
</style>
