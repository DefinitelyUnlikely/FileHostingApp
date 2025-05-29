<script lang="ts">
	import { goto } from '$app/navigation';
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn } from '../../stores/auth';
</script>

{#if !$isLoggedIn}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{:else}
	<p>Redirecting you to homepage.</p>
{/if}

<style>
</style>
