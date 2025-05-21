<script lang="ts">
	import LoginMenu from '../components/loginMenu.svelte';

	import { isLoggedIn, user } from '../stores/auth';
</script>

{#if $isLoggedIn}
	<button onclick={() => isLoggedIn.set(false)}>Logout</button>
{:else}
	<p>Welcome</p>
	<p>Please login to gain access to your cloudstorage</p>
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{/if}

<style>
	p {
		text-align: center;
	}
</style>
