import { writable } from 'svelte/store';
import { getCookie, setCookie } from '../utils/cookies';
import { User } from '$lib/user';

export const isLoggedIn = writable(false);
export const user = writable(new User(''));

export async function login(tokenResponse: Response, userObj: User) {
    let json = await tokenResponse.json();
    setCookie("cred", json);
    user.set(userObj);
    isLoggedIn.set(true);
}

export async function logout() {
    isLoggedIn.set(false);
}