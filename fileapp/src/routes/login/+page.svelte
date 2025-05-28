<script lang="ts">
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn, useremail } from '../../stores/auth';
</script>

{#if $isLoggedIn}
	<p>Welcome {$useremail}!</p>
	<p>
		You are already logged in, to access your files and folders, please go to the <a href="/">
			homescreen.</a
		>
	</p>
	<button onclick={() => isLoggedIn.set(false)}>Logout</button>
{:else}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{/if}

<style>
</style>
