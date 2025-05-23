<script lang="ts">
	import type { LayoutProps } from './$types';
	import { isLoggedIn, useremail } from '../stores/auth';
	import Footer from '../components/footer.svelte';
	import Navbar from '../components/navbar.svelte';

	let { data, children }: LayoutProps = $props();

	isLoggedIn.set(data.isLoggedIn);
	useremail.set(data.useremail);
</script>

<Navbar --color="#0e79b2ff" />

<main>{@render children()}</main>

<Footer --color="#0e79b2ff" />

<style>
</style>
