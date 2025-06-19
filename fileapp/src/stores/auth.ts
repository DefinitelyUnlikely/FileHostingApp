import { writable } from 'svelte/store';
import { getCookie, setCookie, deleteCookie } from '../utils/cookies';
import { User } from '$lib/models';
import { goto } from '$app/navigation';
import { API_BASE_URL } from '$lib/config';

export const isLoggedIn = writable(false);
export const useremail = writable('');

export async function Login(tokenResponse: Response, userObj: User) {
    let json = await tokenResponse.json();
    setCookie("token", json.accessToken);
    setCookie("refresh", json.refreshToken)
    setCookie("userinfo", userObj.email)
    useremail.set(userObj.email);
    isLoggedIn.set(true);
    goto("/")

}

export async function Logout() {
    deleteCookie("token");
    deleteCookie("refresh");
    deleteCookie("userinfo");
    useremail.set('');
    isLoggedIn.set(false);
    goto("/login")
}


export async function RefreshToken() {
    let refresh = getCookie("refresh");
    let refreshRespone = await fetch(API_BASE_URL + "/refresh", {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ refreshtoken: refresh })
    });

    if (!refreshRespone.ok) {
        return false;
    }

    let refreshJson = await refreshRespone.json();
    setCookie("token", refreshJson.accessToken);
    setCookie("refresh", refreshJson.refreshToken);

    return true;
}