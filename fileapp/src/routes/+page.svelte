<script lang="ts">
	import { isLoggedIn, user } from '../stores/auth';
</script>

{#if $isLoggedIn}
	<button onclick={() => isLoggedIn.set(false)}>Logout</button>
{:else}
	<div class="login-window">
		<label for="email-input">Email:</label>
		<input type="email" name="email" id="email" />
		<label for="password" style="margin-top: 1rem;">Password:</label>
		<input type="password" name="password" id="password" />
	</div>
{/if}

<style>
	.login-window {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		margin-top: 20%;
		width: 90%;
		height: 50%;
		background-color: whitesmoke;
		border-radius: 10px;
	}
</style>
