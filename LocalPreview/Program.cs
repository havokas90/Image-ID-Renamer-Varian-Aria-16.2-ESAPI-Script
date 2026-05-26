using System;
using System.Collections.Generic;
using System.Windows;
using VMS.TPS;

namespace EclipseImageRenamer.LocalPreview
{
    public static class Program
    {
        [STAThread]
        public static void Main()
        {
            var app = new Application();
            app.Run(new EclipseImageRenamerWindow(BuildSampleCandidates()));
        }

        private static List<RenameCandidate> BuildSampleCandidates()
        {
            return new List<RenameCandidate>
            {
                Candidate("MR", "MR1", "MR_T2_AX_HN", "_HN", "t2_ax_2.0mm", "Head and Neck MRI"),
                Candidate("MR", "MR2", "MR_B1000_HN", "_HN", "ep2d_diff_b1000_3.0mm", "Head and Neck MRI"),
                Candidate("MR", "MR3", "MR_T1_POST_HN", "_HN", "t1 post contrast", "Head and Neck MRI"),
                Candidate("CT", "CT1", "CT_SIM_PEL", "_PEL", "CT SIM 2.5mm", "Pelvis planning CT"),
                Candidate("CT", "CT2", "CT_4D_CH", "_CH", "4D CT chest", "Thorax 4DCT"),
                Candidate("MR", "OLD_LONG_NAME", "MR_T2_SPACE_BR", "_BR", "T2 SPACE brain 1.0mm", "Brain MRI"),
                Candidate("MR", "MR_UNCHANGED_BR", "MR_UNCHANGED_BR", "_BR", "Already correct image ID", "Brain MRI"),
                Candidate("CT", "CT_EXISTING_PEL", "CT_EXISTING_PEL", "_PEL", "Existing pelvis image kept for duplicate testing", "Pelvis planning CT", false),
                Candidate("CT", "CT_DUP_TEST", "CT_EXISTING_PEL", "_PEL", "Edited ID collides with an existing patient image", "Pelvis planning CT"),
                Candidate("MR", "MR_LONG", "MR_VERY_LONG_BR", "_BR", "Very long scanner description example", "Brain MRI"),
                Candidate("MR", "MR_SYMBOLS", "MR_BAD NAME!*", "_BR", "Edited ID with spaces and symbols", "Brain MRI")
            };
        }

        private static RenameCandidate Candidate(string modality, string currentId, string newId, string suffix, string series, string study, bool selected = true)
        {
            return new RenameCandidate
            {
                Modality = modality,
                CurrentId = currentId,
                NewId = newId,
                Suffix = suffix,
                SeriesDescription = series,
                StudyDescription = study,
                IsSelected = selected
            };
        }
    }
}
