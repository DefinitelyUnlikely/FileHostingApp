<script lang="ts">
	import { isLoggedIn, user } from '../stores/auth';
</script>

{#if $isLoggedIn}
	Hej
{:else}
	Hej
{/if}

<style>
</style>
