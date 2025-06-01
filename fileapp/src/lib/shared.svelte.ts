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