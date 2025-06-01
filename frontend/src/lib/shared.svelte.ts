import AddBookingModal from "../routes/createBooking/+page.svelte";

export const isModalVisible = $state(
    {
        addActivityModal: false,
        addRoomModal: false,
        editActivityModal: false,
        editRoomModal: false,
    }
)