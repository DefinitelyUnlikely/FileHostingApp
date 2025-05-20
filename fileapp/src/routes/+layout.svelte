<script lang="ts">
	import Footer from '../components/footer.svelte';
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar />

<main>{@render children()}</main>

<Footer />

<style>
</style>
