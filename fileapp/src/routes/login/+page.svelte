<script lang="ts">
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn, user } from '../../stores/auth';
</script>

{#if $isLoggedIn}
	<p>Welcome!</p>
	<button onclick={() => isLoggedIn.set(false)}>Logout</button>
{:else}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{/if}

<style>
</style>
