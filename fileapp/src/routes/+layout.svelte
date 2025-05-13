<script lang="ts">
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

{@render children()}

<style>
	:global(body) {
		background-color: rgb(41, 41, 41);
		margin: 0;
		display: flex;
		flex-direction: column;
		justify-content: flex-start;
		align-items: center;
	}

	:global(h1) {
		color: white;
	}

	:global(h2) {
		color: white;
	}

	:global(p) {
		color: white;
	}

	:global(label) {
		color: white;
	}
</style>
