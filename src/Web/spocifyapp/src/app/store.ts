import { configureStore, ThunkAction, Action } from '@reduxjs/toolkit';
import authSlice from './pages/login/redux/login.slice';
import snackSlice from './components/snackbar/redux/snackbarslice.slice'
import { throttle } from 'lodash';
import StorageAppService from './core/services/storage.service';
import dashboardSlice from './pages/dashboard/redux/dashboard.slice';
export const store = configureStore({
	reducer: {
		login: authSlice,
		snack: snackSlice,
		dashboard: dashboardSlice
	},
});

store.subscribe(
	throttle(() => {
		if (process.env.NODE_ENV === "development") {
			console.info("state", store.getState());
			console.info("actions", store.dispatch);
		}
		StorageAppService.SaveState({
			...store.getState(),
		});
	}, 1000),
);

export type AppDispatch = typeof store.dispatch;
export type RootState = ReturnType<typeof store.getState>;
export type AppThunk<ReturnType = void> = ThunkAction<
	ReturnType,
	RootState,
	unknown,
	Action<string>
>;
