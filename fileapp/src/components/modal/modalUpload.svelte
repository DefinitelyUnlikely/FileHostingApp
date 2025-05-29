<script lang="ts">
	import { isXModalVisible } from '$lib/shared.svelte';
	import { getCookie } from '../../utils/cookies';
	import { invalidateAll } from '$app/navigation';

	async function Upload() {
		await invalidateAll();
	}
</script>

<div class="upload-modal">
	<h3>Upload File</h3>
	<p>The file will be upload to the current directory</p>
	<button onclick={Upload}>Upload</button>
	<button class="close" onclick={() => (isXModalVisible.upload = !isXModalVisible.upload)}>X</button
	>
</div>

<style>
	.upload-modal {
		z-index: 100;
		position: fixed;
		width: 90%;
		height: 70%;
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
