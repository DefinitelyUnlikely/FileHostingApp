<script lang="ts">
	import { isLoggedIn, Logout, useremail } from '../stores/auth';
	import { Hamburger } from 'svelte-hamburgers';
	import { slide } from 'svelte/transition';

	let open = $state(false);

	function changeOpenState() {
		open = !open;
	}

	function NavbarLogout() {
		changeOpenState();
		Logout();
	}
</script>

<nav>
	<div class="left-nav"></div>
	<div class="middle-nav"><h1>Sunset Drive</h1></div>
	<div class="right-nav">
		<Hamburger bind:open title="Toogle a menu with navigation" --color="#ebebebff" type="minus" />
	</div>
</nav>
{#if open}
	<div class="hamburger-dropdown" transition:slide>
		<h3><a href="/" onclick={changeOpenState}>Home</a></h3>
		{#if $isLoggedIn}
			<h3><a href="/login" onclick={NavbarLogout}>Logout</a></h3>
		{:else}
			<h3><a href="/login" onclick={changeOpenState}>Login</a></h3>
		{/if}
	</div>
{/if}

<style>
	nav {
		display: grid;
		grid-template-columns: 2fr 8fr 2fr;
		background-color: var(--color, #0e79b2ff);
		width: 100vw;
		height: 4rem;
		gap: 0.5rem;
		flex-shrink: 0;
	}

	.middle-nav {
		display: flex;
		align-items: center;
		justify-content: center;
	}
	.middle-nav > h1 {
		color: #ebebebff;
	}
	.right-nav {
		display: flex;
		justify-content: end;
		align-items: center;
	}

	.hamburger-dropdown {
		position: absolute;
		top: 4rem;
		left: 0;
		width: 100%;
		height: 15vh;
		z-index: 100;
		background-color: var(--dropdowncolor, #0e79b2ff);
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
	}

	.hamburger-dropdown h3 {
		margin: 0.5rem;
	}

	.hamburger-dropdown a {
		text-decoration: none;
		color: #ebebebff;
	}

	h1 {
		font-size: 1.5rem;
		margin: 0;
	}
</style>
