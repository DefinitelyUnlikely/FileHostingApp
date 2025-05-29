<script lang="ts">
	import type { PageData } from '../routes/$types';
	import { useremail, Logout } from '../stores/auth';
	import Resourceview from '../components/resourceview.svelte';
	import { isXModalVisible } from '$lib/shared.svelte';

	function ShowFolderModal() {
		isXModalVisible.folder = !isXModalVisible.folder;
	}
	function ShowUploadModal() {
		isXModalVisible.upload = !isXModalVisible.upload;
	}

	function OnKeyDownFolder(event: KeyboardEvent) {
		if (event.key === 'Enter') {
			event.preventDefault();
			ShowFolderModal();
		}
	}

	function OnKeyDownUpload(event: KeyboardEvent) {
		if (event.key === 'Enter') {
			event.preventDefault();
			ShowUploadModal();
		}
	}

	export let props: PageData;
</script>

<div class="drive">
	<p>Welcome {$useremail}</p>
	<div class="create">
		<button class="create-button">+Create</button>
		<div class="create-dropdown">
			<!-- svelte-ignore a11y_no_noninteractive_element_interactions -->
			<p onclick={ShowFolderModal} onkeydown={OnKeyDownFolder}>New Folder</p>
			<hr style="width: 70%;" />
			<!-- svelte-ignore a11y_no_noninteractive_element_interactions -->
			<p onclick={ShowUploadModal} onkeydown={OnKeyDownUpload}>Upload File</p>
		</div>
	</div>
	<hr style="width:90%;text-align:center;" />
	<Resourceview resources={props} />
	<button class="logout" onclick={Logout}>Logout</button>
</div>

<style>
	.drive {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
		height: 100%;
		width: 100%;
	}

	.create-dropdown {
		display: none;
		position: absolute;
		background-color: #f9f9f9;
		box-shadow: 0px 8px 16px 0px rgba(0, 0, 0, 0.2);
		padding: 12px 16px;
		z-index: 10;
	}

	.create:hover .create-dropdown {
		display: flex;
		flex-direction: column;
	}

	.logout {
		margin-top: auto;
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

	@media only screen and (min-width: 600px) {
		.create {
			margin-right: auto;
		}
	}

	.create-dropdown > p {
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
		position: relative;
	}

	.create-dropdown > p::before {
		position: absolute;
		content: '';
		background: var(--color);
		width: 250px;
		height: 200px;
		z-index: -1;
		border-radius: 50%;
	}

	.create-dropdown > p:hover {
		color: white;
	}

	.create-dropdown > p:before {
		top: 100%;
		left: 100%;
		transition: 0.3s all;
	}

	.create-dropdown > p:hover::before {
		top: -40px;
		left: -40px;
	}
</style>
