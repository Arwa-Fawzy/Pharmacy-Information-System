namespace Namespace {
    
    using sqlite3;
    
    public static class Module {
        
        public static object add() {
            var con = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
            var cur = con.cursor();
            cur.execute("CREATE TABLE IF NOT EXISTS Information(REF_NO text PRIMARY KEY,COMPANY_NAME text,TYPE_OF_MED text,MED_NAME text,LOT_NO text,ISSUE_DT text,EXP_DT text,USES text,SIDE_EFFECT text,PRECAUTION text,DOSAGE text,PRICE text,QUANTITY text)");
            con.commit();
        }
        
        static Module() {
            add();
        }
    }
}
