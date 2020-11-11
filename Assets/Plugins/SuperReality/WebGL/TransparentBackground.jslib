const LibraryGLClear = {
    glClear: function(mask)
    {
        if (mask === GLctx.COLOR_BUFFER_BIT)
        {
            const mask = GLctx.getParameter(GLctx.COLOR_WRITEMASK);
            if (!mask[0] && !mask[1] && !mask[2] && mask[3]) return;
        }
        GLctx.clear(mask);
    }
};

mergeInto(LibraryManager.library, LibraryGLClear);
