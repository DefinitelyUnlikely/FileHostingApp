<script lang="ts">
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

{@render children()}

<style>
	:global(body) {
		background-color: rgb(255, 255, 255);
		margin: 0;
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	:global(h1) {
		color: rgb(0, 0, 0);
	}

	:global(h2) {
		color: black;
	}

	:global(p) {
		color: black;
	}

	:global(label) {
		color: black;
	}
</style>
