import { redirect } from "@sveltejs/kit";
import { deleteCookie, getCookie, setCookie } from "../utils/cookies";
import { API_BASE_URL } from "./config";

export const isXModalVisible = $state<Record<string, boolean>>(
    {
        upload: false,
        folder: false,
    }
)

export function formatDateTime(dateString: string): string {
    const date = new Date(dateString);
    return date.toISOString().slice(0, 16).replace('T', ' ');
}

export async function tryRefreshToken() {
    let refresh = getCookie("refresh");
    let refreshRespone = await fetch(API_BASE_URL + "/refresh", {
        method: 'POST',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ refreshtoken: refresh })
    });

    console.log(refreshRespone);

    if (!refreshRespone.ok) {
        deleteCookie("userinfo");
        deleteCookie("token");
        deleteCookie("refresh");
        redirect(303, "/login")
    }

    let refreshJson = await refreshRespone.json();
    setCookie("token", refreshJson.accessToken)
    setCookie("refresh", refreshJson.refreshToken)
}