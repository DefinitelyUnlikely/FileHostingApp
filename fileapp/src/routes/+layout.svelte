<script lang="ts">
	import Footer from '../components/footer.svelte';
	import Navbar from '../components/navbar.svelte';

	let { children } = $props();
</script>

<Navbar --color="#0e79b2ff" />

<main>{@render children()}</main>

<Footer --color="#0e79b2ff" />

<style>
</style>
