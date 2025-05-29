<script lang="ts">
	import { goto } from '$app/navigation';
	import LoginMenu from '../../components/loginMenu.svelte';
	import { isLoggedIn, useremail } from '../../stores/auth';
</script>

{#if $isLoggedIn}
	{goto('/')}
{:else}
	<LoginMenu --height="50%" --width="80%" --top-margin="10%" />
{/if}

<style>
</style>
