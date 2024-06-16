import { create } from "zustand"

type State = {
    orderBy: string
    filterBy: string
    pageSize: number
    pageCount: number
    pageNumber: number
    searchTerm: string
    searchValue: string
}

type Actions = {
    reset: () => void
    setSearchValue: (value: string) => void
    setParams: (params: Partial<State>) => void
}

const initialState: State = {
    pageSize: 12,
    pageCount: 1,
    pageNumber: 1,

    orderBy: '',
    filterBy: '',
    searchTerm: '',
    searchValue: 'make',
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
    reset: () => set(initialState),
    setSearchValue: (value: string) => {
        set({ searchValue: value })
    }
}))