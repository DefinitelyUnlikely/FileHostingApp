<script lang="ts">
	import type { PageData } from './$types';
	import { goto } from '$app/navigation';
	import Resourceview from '../components/resourceview.svelte';
	import { isLoggedIn, useremail, Logout } from '../stores/auth';
	import { onMount } from 'svelte';

	let { data }: { data: PageData } = $props();

	onMount(() => {
		if (!$isLoggedIn) {
			goto('/login');
		}
	});
</script>

{#if $isLoggedIn}
	<div class="drive">
		<div class="top-drive">
			<button>+Create</button>
			<p>Welcome {$useremail}</p>
			<div></div>
		</div>
		<Resourceview folders={data.response.subFolders} files={data.response.files} />
		<button class="logout" onclick={Logout}>Logout</button>
	</div>
{/if}

<style>
	.drive {
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
		height: 100%;
		width: 100%;
	}

	.top-drive {
		width: 100%;
		display: grid;
		align-items: center;
		grid-template-columns: 2fr 8fr 2fr;
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
</style>
