import AddBookingModal from "../components/modal/addBookingModal.svelte";

export const isModalVisible = $state(
    {
        addActivityModal: false,
        addRoomModal: false,
        editActivityModal: false,
        editRoomModal: false,
        addBookingModal: false
    }
)