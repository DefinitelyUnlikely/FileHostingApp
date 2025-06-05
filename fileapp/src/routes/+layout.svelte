<script lang="ts">
	import type { LayoutProps } from './$types';
	import { isLoggedIn, Logout, useremail } from '../stores/auth';
	import Footer from '../components/footer.svelte';
	import Navbar from '../components/navbar.svelte';

	let { data, children }: LayoutProps = $props();

	isLoggedIn.set(data.isLoggedIn);
	useremail.set(data.useremail);
</script>

<Navbar --color="#0e79b2ff" />

<main>
	{@render children()}
	{#if isLoggedIn}
		<button class="logout" onclick={Logout}>Logout</button>
	{/if}
</main>

<Footer --color="#0e79b2ff" />

<style>
	.logout {
		margin-top: auto;
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
