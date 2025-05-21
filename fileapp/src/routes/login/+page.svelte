<script lang="ts">
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn, user } from '../../stores/auth';

	let email: string = $state('');
	let password: string = $state('');
</script>

{#if $isLoggedIn}
	<p>Welcome!</p>
{:else}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{/if}

<style>
</style>
