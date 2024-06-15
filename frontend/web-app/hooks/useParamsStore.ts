import { create } from "zustand"

type State = {
    pageSize: number
    pageCount: number
    pageNumber: number
    searchTerm: string
}

type Actions = {
    reset: () => void
    setParams: (params: Partial<State>) => void
}

const initialState: State = {
    pageSize: 12,
    pageCount: 1,
    pageNumber: 1,
    searchTerm: ''
}

export const useParamsStore = create<State & Actions>()((set) => ({
    ...initialState,
    setParams: (newParams: Partial<State>) => {
        set((state: State) => {
            if (newParams.pageNumber) {
                return { ...state, pageNumber: newParams.pageNumber };
            } else {
                return { ...state, ...newParams, pageNumber: 1 };
            }
        })
    },
    reset: () => set(initialState)
}))