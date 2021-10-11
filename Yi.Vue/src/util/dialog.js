function notify(resp) {
    if (resp.status) {
        this.$dialog.notify.success(resp.msg, {
            position: "top-right",
        });
    } else {
        this.$dialog.notify.error(resp.msg, {
            position: "top-right",
        });
    }
};

export default { notify };