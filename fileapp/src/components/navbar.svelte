<script lang="ts">
	import { Hamburger } from 'svelte-hamburgers';
	import { slide } from 'svelte/transition';

	let open = $state(false);
</script>

<nav>
	<div class="left-nav"></div>
	<div class="middle-nav"><h1>Sunset Drive</h1></div>
	<div class="right-nav">
		<Hamburger bind:open title="Toogle a menu with navigation" --color="white" type="elastic" />
	</div>
</nav>
{#if open}
	<div class="hamburger-dropdown" transition:slide></div>
{/if}

<style>
	nav {
		display: grid;
		grid-template-columns: 2fr 8fr 2fr;
		background-color: skyblue;
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
		color: white;
	}
	.right-nav {
		display: flex;
		justify-content: end;
		align-items: center;
	}

	.hamburger-dropdown {
		height: 40vh;
		background-color: skyblue;
	}
</style>
