<script lang="ts">
	import Footer from '../components/footer.svelte';
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

{@render children()}

<Footer />

<style>
	:global(body) {
		margin: 0;
		background-color: rgb(255, 255, 255);
		overflow: hidden;
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
