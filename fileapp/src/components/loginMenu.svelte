<script lang="ts">
	let email: string = $state('');
	let password: string = $state('');
</script>

<div class="login-window">
	<h2>Login</h2>
	<label for="email-input">Email:</label>
	<input type="email" name="email" id="email" placeholder="enter email..." bind:value={email} />
	<label for="password" style="margin-top: 1rem;">Password:</label>
	<input
		type="password"
		name="password"
		id="password"
		style="margin-bottom: 1rem;"
		placeholder="enter password..."
		bind:value={password}
	/>
	<p>Don't have an account yet?</p>
	<p>Register <a href="/register">here</a></p>
</div>

<style>
	.login-window {
		display: flex;
		flex-direction: column;
		justify-content: center;
		align-items: center;
		margin-top: var(--top-margin);
		width: var(--width);
		height: var(--height);
		background-color: var(--background-color, #ebebebff);
		border: 2px solid var(--border-color, #d6d6d6ff);
		border-radius: 10px;
	}

	p {
		margin: 0;
	}
</style>
