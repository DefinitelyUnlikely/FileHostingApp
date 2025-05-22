<script lang="ts">
	import LoginMenu from '../components/loginMenu.svelte';
	import { getCookie } from '../utils/cookies';
	import { isLoggedIn, useremail, Logout } from '../stores/auth';
	import { API_BASE_URL } from '$lib/config';

	async function getFolders() {
		let token = getCookie('token');

		let response = await fetch(API_BASE_URL + '/folder/folders');
	}

	if (isLoggedIn) {
		getFolders();
	}
</script>

{#if $isLoggedIn}
	<p>Welcome {$useremail}</p>
	<button onclick={Logout}>Logout</button>
{:else}
	<p>Welcome</p>
	<p>Please login to gain access to your cloudstorage</p>
	<LoginMenu --height="50%" --width="80%" --top-margin="5%" />
{/if}

<style>
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
