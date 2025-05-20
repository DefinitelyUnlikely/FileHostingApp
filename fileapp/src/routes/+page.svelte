<script lang="ts">
	import { isLoggedIn, user } from '../stores/auth';
</script>

{#if $isLoggedIn}
	<button onclick={() => isLoggedIn.set(false)}>Logout</button>
{:else}
	<button onclick={() => isLoggedIn.set(true)}>Login</button>
{/if}

<style>
</style>
