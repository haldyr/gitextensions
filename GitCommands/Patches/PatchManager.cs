        public static byte[] GetResetUnstagedLinesAsPatch([NotNull] GitModule module, [NotNull] string text, int selectionPosition, int selectionLength, [NotNull] Encoding fileContentEncoding)
            string body = ToResetUnstagedLinesPatch(selectedChunks);
        public static byte[] GetSelectedLinesAsPatch([NotNull] string text, int selectionPosition, int selectionLength, bool staged, [NotNull] Encoding fileContentEncoding, bool isNewFile)
            string body = ToStagePatch(selectedChunks, staged, isWholeFile: false);
            StringBuilder sb = new StringBuilder();
        public static byte[] GetSelectedLinesAsNewPatch([NotNull] GitModule module, [NotNull] string newFileName, [NotNull] string text, int selectionPosition, int selectionLength, [NotNull] Encoding fileContentEncoding, bool reset, byte[] filePreabmle)
            StringBuilder sb = new StringBuilder();
            var selectedChunks = FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreabmle, fileContentEncoding);
            string body = ToStagePatch(selectedChunks, staged: false, isWholeFile: true);
                // if selection intersects with chunsk
        private static IReadOnlyList<Chunk> FromNewFile([NotNull] GitModule module, [NotNull] string text, int selectionPosition, int selectionLength, bool reset, [NotNull] byte[] filePreabmle, [NotNull] Encoding fileContentEncoding)
                Chunk.FromNewFile(module, text, selectionPosition, selectionLength, reset, filePreabmle, fileContentEncoding)
        private static string ToResetUnstagedLinesPatch([NotNull, ItemNotNull] IEnumerable<Chunk> chunks)
                return subChunk.ToResetUnstagedLinesPatch(ref addedCount, ref removedCount, ref wereSelectedLines);
        private static string ToStagePatch([NotNull, ItemNotNull] IEnumerable<Chunk> chunks, bool staged, bool isWholeFile)
                return subChunk.ToStagePatch(ref addedCount, ref removedCount, ref wereSelectedLines, staged, isWholeFile);
        public string ToStagePatch(ref int addedCount, ref int removedCount, ref bool wereSelectedLines, bool staged, bool isWholeFile)
                else if (!staged)
                else if (staged)
            if (PostContext.Count == 0 && (!staged || selectedLastRemovedLine))
            if (PostContext.Count == 0 && (selectedLastLine || staged || isWholeFile))
        public string ToResetUnstagedLinesPatch(ref int addedCount, ref int removedCount, ref bool wereSelectedLines)
            Chunk result = new Chunk();
                    // do not refactor, there are no break points condition in VS Experss
        public static Chunk FromNewFile([NotNull] GitModule module, [NotNull] string fileText, int selectionPosition, int selectionLength, bool reset, [NotNull] byte[] filePreabmle, [NotNull] Encoding fileContentEncoding)
            Chunk result = new Chunk { _startLine = 0 };
                string preamble = i == 0 ? new string(fileContentEncoding.GetChars(filePreabmle)) : string.Empty;