export interface SpocifySnackBarOptions {
    message: string;
    severity: "success" | "info" | "warning" | "error";
    title?: string;
    open?: boolean;
    autoHideDuration?: number | null | undefined;
    action?: (result: boolean) => void;
}