const SendBufferedMessages = {
    SendBufferedMessages: function()
    {
        window.postMessage({type: "SEND_BUFFERED_MESSAGES", payload: {}}, "*");
    }
};

mergeInto(LibraryManager.library, SendBufferedMessages);
