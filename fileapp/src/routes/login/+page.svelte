<script lang="ts">
	import { goto } from '$app/navigation';
	import { onMount } from 'svelte';
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn } from '../../stores/auth';

	onMount(() => {
		if ($isLoggedIn) {
			goto('/');
		}
	});
</script>

<svelte:head>
	<title>Sunset Drive &#x2022 Login</title>
</svelte:head>

{#if !$isLoggedIn}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{:else}
	<p>Redirecting you to homepage.</p>
{/if}

<style>
</style>
