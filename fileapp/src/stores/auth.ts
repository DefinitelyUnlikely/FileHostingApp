import { writable } from 'svelte/store';

export const isLoggedIn = writable(false);
export const user = writable('replace with an user object or similar');


export function login() {
    user.set("Mocked logged in");
    isLoggedIn.set(true);

}

export function logout() {
    user.set("mock");
    isLoggedIn.set(false);

}