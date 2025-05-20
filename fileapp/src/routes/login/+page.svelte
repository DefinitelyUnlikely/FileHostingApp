<script lang="ts">
	import { isLoggedIn, user } from '../../stores/auth';

	let email: string = $state('');
	let password: string = $state('');
</script>

{#if $isLoggedIn}
	<p>You are logged in as: {$user}</p>
{:else}
	<h4>Login</h4>
	<p>Don't have an account yet?</p>
	<p>Register <a href="/register">here</a></p>
{/if}

<style>
	p {
		margin: 0;
	}
</style>
