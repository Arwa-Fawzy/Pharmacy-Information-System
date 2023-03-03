namespace Namespace {
    
    using random;
    
    using ttk = tkinter.ttk;
    
    using messagebox = tkinter.messagebox;
    
    using sqlite3;
    
    using Image = PIL.Image;
    
    using ImageTk = PIL.ImageTk;
    
    using tkinter.simpledialog;
    
    using tk = tkinter;
    
    using pdf = pdf.pdf;
    
    using System.Collections.Generic;
    
    public static class Module {
        
        public class Pharmacy {
            
            public Pharmacy(object root) {
                this.root = root;
                this.root.title("Pharm.B (Pharmacy Builder)");
                this.root.geometry("1350x800+0+0");
                this.root.resizable(false, false);
                this.root.iconbitmap(@"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/image/doc.ico");
                this.ref_variable = StringVar();
                this.addmed_variable = StringVar();
                //variables of the departments
                this.refno_var = StringVar();
                this.companyname_var = StringVar();
                this.typemed_var = StringVar();
                this.medicine_var = StringVar();
                this.lotno_var = StringVar();
                this.issuedt_var = StringVar();
                this.expdt_var = StringVar();
                this.uses_var = StringVar();
                this.sideeffect_var = StringVar();
                this.warning_var = StringVar();
                this.dosage_var = StringVar();
                this.price_var = StringVar();
                this.quantity_var = StringVar();
                this.search_by = StringVar();
                this.search_txt = StringVar();
                //style of the title text
                this.txt = "Pharm.B (Builder of Pharmacy)";
                this.count = 0;
                this.text = "";
                this.color = new List<object> {
                    "cornsilk1"
                };
                this.heading = Label(this.root, text: this.txt, font: ("times new roman", 30, "bold"), bg: "dodgerblue4", fg: "blue", bd: 9, relief: RIDGE);
                this.heading.pack(side: TOP, fill: X);
                this.heading_color();
                //logo label text style 
                var img1 = Image.open(@"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/image/logo.png");
                img1 = img1.resize((70, 45), Image.ANTIALIAS);
                this.photoimg1 = ImageTk.PhotoImage(img1);
                var b1 = Button(this.root, image: this.photoimg1, borderwidth: 0, bg: "dodgerblue4");
                b1.place(x: 15, y: 8);
                //the top frame style
                var topframe = Frame(this.root, bg: "aliceblue", bd: 10, relief: RIDGE, padx: 20);
                topframe.place(x: 0, y: 62, width: 1350, height: 400);
                //#######  down button frame #######
                var down_buttonframe = Frame(this.root, bg: "dodgerblue4", bd: 10, relief: RIDGE, padx: 20);
                down_buttonframe.place(x: 0, y: 462, width: 1350, height: 60);
                //##### all buttons ######
                var add_button = Button(down_buttonframe, text: "Add Medicine", command: this.addmedicine, font: ("arial", 12, "bold"), width: 14, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "aliceblue", activeforeground: "white");
                add_button.grid(row: 0, column: 0);
                var update_button = Button(down_buttonframe, command: this.update_new, text: "Update", font: ("arial", 13, "bold"), width: 14, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white");
                update_button.grid(row: 0, column: 1);
                var delete_button = Button(down_buttonframe, text: "Delete", font: ("arial", 13, "bold"), width: 13, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white");
                delete_button.grid(row: 0, column: 2);
                var reset_button = Button(down_buttonframe, text: "Reset", command: this.clear_new, font: ("arial", 13, "bold"), width: 12, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white");
                reset_button.grid(row: 0, column: 3);
                var exit_button = Button(down_buttonframe, command: this.root.quit, text: "Exit", font: ("arial", 13, "bold"), width: 10, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white");
                exit_button.grid(row: 0, column: 4);
                var search_by = Label(down_buttonframe, text: "Search by", font: ("arial", 10, "bold"), fg: "white", bg: "dodgerblue4", bd: 3, padx: 3);
                search_by.grid(row: 0, column: 5, sticky: W);
                this.search_combo = ttk.Combobox(down_buttonframe, width: 12, font: ("arial", 13, "bold"), state: "readonly", textvariable: this.search_by);
                this.search_combo["values"] = ("Select Options", "Ref No.");
                this.search_combo.grid(row: 0, column: 6);
                this.search_combo.current(0);
                var entry_button = Entry(down_buttonframe, font: ("arial", 15, "bold"), fg: "black", bg: "aliceblue", bd: 3, width: 12, relief: RIDGE, textvariable: this.search_txt);
                entry_button.grid(row: 0, column: 7);
                var search_button = Button(down_buttonframe, text: "Search", font: ("arial", 13, "bold"), width: 10, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white", command: this.search_data);
                search_button.grid(row: 0, column: 8);
                var show_button = Button(down_buttonframe, text: "Show All", font: ("arial", 13, "bold"), fg: "black", bg: "aliceblue", width: 10, bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white", command: this.fetch_new);
                show_button.grid(row: 0, column: 9);
                //####### left small frame #######
                var left_smallframe = LabelFrame(topframe, bg: "dodgerblue4", bd: 10, relief: RIDGE, padx: 20, text: "Medicine Information", font: ("arial", 13, "bold"), fg: "white");
                left_smallframe.place(x: 0, y: 5, width: 820, height: 350);
                //### labeling & entry box #########
                // 1
                var ref_label = Label(left_smallframe, text: "Reference No. :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                ref_label.grid(row: 0, column: 0, sticky: W);
                var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                var my_cursor = conn.cursor();
                my_cursor.execute("Select Ref_no from pharma");
                var row_01 = my_cursor.fetchall();
                this.ref_combo = ttk.Combobox(left_smallframe, textvariable: this.refno_var, width: 22, font: ("times new roman", 13, "bold"), state: "readonly");
                this.ref_combo["values"] = ("Select", row_01);
                this.ref_combo.grid(row: 0, column: 1);
                this.ref_combo.current(0);
                // 2
                var company_label = Label(left_smallframe, text: "Company Name  :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                company_label.grid(row: 1, column: 0);
                this.company_entry = Entry(left_smallframe, textvariable: this.companyname_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.company_entry.grid(row: 1, column: 1);
                // 3
                var type_label = Label(left_smallframe, text: "Type Of Medicine :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                type_label.grid(row: 2, column: 0, sticky: W);
                this.type_combo = ttk.Combobox(left_smallframe, textvariable: this.typemed_var, width: 22, font: ("times new roman", 13, "bold"), state: "readonly");
                this.type_combo["values"] = (" Select  ", "Tablet", "Capsule", "Injection", "Ayurvedic", "Drops", "Inhales", "Liquid", "Ointment", "Cream");
                this.type_combo.grid(row: 2, column: 1);
                this.type_combo.current(0);
                // 4
                var medname_label = Label(left_smallframe, text: "Medicine Name :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                medname_label.grid(row: 3, column: 0, sticky: W);
                conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                my_cursor = conn.cursor();
                my_cursor.execute("Select Med_name from pharma");
                var row_02 = my_cursor.fetchall();
                this.medname_combo = ttk.Combobox(left_smallframe, textvariable: this.medicine_var, width: 22, font: ("times new roman", 13, "bold"), state: "readonly");
                this.medname_combo["values"] = ("Select", row_02);
                this.medname_combo.grid(row: 3, column: 1);
                this.medname_combo.current(0);
                // 5
                var lot_label = Label(left_smallframe, text: " Lot No. :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                lot_label.grid(row: 4, column: 0);
                this.lot_entry = Entry(left_smallframe, textvariable: this.lotno_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.lot_entry.grid(row: 4, column: 1);
                // 6
                var issue_label = Label(left_smallframe, text: " Issue Date :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                issue_label.grid(row: 5, column: 0);
                this.issue_entry = Entry(left_smallframe, textvariable: this.issuedt_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.issue_entry.grid(row: 5, column: 1);
                // 7
                var exp_label = Label(left_smallframe, text: " Expiry Date :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                exp_label.grid(row: 6, column: 0);
                this.exp_entry = Entry(left_smallframe, textvariable: this.expdt_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.exp_entry.grid(row: 6, column: 1);
                // 8
                var use_label = Label(left_smallframe, text: " Uses :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                use_label.grid(row: 7, column: 0);
                this.use_entry = Entry(left_smallframe, textvariable: this.uses_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.use_entry.grid(row: 7, column: 1);
                // 9
                var sideeffect_label = Label(left_smallframe, text: " Side Effect :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                sideeffect_label.grid(row: 8, column: 0);
                this.sideeffect_entry = Entry(left_smallframe, textvariable: this.sideeffect_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.sideeffect_entry.grid(row: 8, column: 1);
                // 10
                var warn_label = Label(left_smallframe, text: " Prec & warning:", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                warn_label.grid(row: 9, column: 0);
                this.warn_entry = Entry(left_smallframe, textvariable: this.warning_var, width: 24, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.warn_entry.grid(row: 9, column: 1);
                // 11
                var dosage_label = Label(left_smallframe, text: " Dosage :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                dosage_label.grid(row: 0, column: 2);
                this.dosage_entry = Entry(left_smallframe, textvariable: this.dosage_var, width: 28, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.dosage_entry.grid(row: 0, column: 3);
                // 12
                var price_label = Label(left_smallframe, text: " Tablet Price :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                price_label.grid(row: 1, column: 2);
                this.price_entry = Entry(left_smallframe, textvariable: this.price_var, width: 28, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.price_entry.grid(row: 1, column: 3);
                // 13
                var qt_label = Label(left_smallframe, text: " Tablet Quantity :", padx: 2, pady: 4, font: ("times new roman", 13, "bold"), bg: "dodgerblue4", fg: "white");
                qt_label.grid(row: 2, column: 2);
                this.qt_entry = Entry(left_smallframe, textvariable: this.quantity_var, width: 28, font: ("times new roman", 13, "bold"), fg: "black", bg: "white");
                this.qt_entry.grid(row: 2, column: 3);
                //inserting some images in the left frame
                // image 
                this.bgg = ImageTk.PhotoImage(file: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/image/medi.png");
                var lbl_bgg = Label(left_smallframe, image: this.bgg);
                lbl_bgg.place(x: 380, y: 100, width: 390, height: 210);
                //########### right frame #########
                var right_frame = LabelFrame(topframe, bg: "dodgerblue4", bd: 10, relief: RIDGE, padx: 5, text: "New Medicine Add department", font: ("arial", 13, "bold"), fg: "white");
                right_frame.place(x: 846, y: 5, width: 452, height: 350);
                // image & label
                // image 
                this.bg1 = ImageTk.PhotoImage(file: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/image/co.jpeg");
                var lbl_bg1 = Label(right_frame, image: this.bg1);
                lbl_bg1.place(x: 0, y: 0, width: 420, height: 100);
                //### label & entry in right frame ####
                // 1
                var no_label = Label(right_frame, text: "Reference No:", font: ("times new roman", 11, "bold"), bg: "dodgerblue4", fg: "white");
                no_label.place(x: 85, y: 105);
                this.no_entry = Entry(right_frame, textvariable: this.ref_variable, width: 16, font: ("times new roman", 11, "bold"), bg: "white");
                this.no_entry.place(x: 200, y: 105);
                // 2
                var med_label = Label(right_frame, text: "Med. Name:", font: ("times new roman", 11, "bold"), bg: "dodgerblue4", fg: "white");
                med_label.place(x: 0, y: 130);
                this.med_entry = Entry(right_frame, textvariable: this.addmed_variable, width: 16, font: ("times new roman", 11, "bold"), bg: "white");
                this.med_entry.place(x: 100, y: 130);
                //### in right frame small frame #####
                var newframe = Frame(right_frame, bg: "aliceblue", bd: 5, relief: RIDGE);
                newframe.place(x: 256, y: 160, width: 150, height: 150);
                //##### button in this frame ###
                add_button = Button(newframe, text: "Add", font: ("arial", 13, "bold"), width: 13, fg: "black", bg: "aliceblue", bd: 3, command: this.AddMed, relief: RIDGE, activebackground: "black", activeforeground: "white");
                add_button.grid(row: 0, column: 0);
                var updatenew_button = Button(newframe, text: "Update", font: ("arial", 13, "bold"), width: 13, fg: "black", bg: "aliceblue", bd: 3, command: this.Update_med, relief: RIDGE, activebackground: "black", activeforeground: "white");
                updatenew_button.grid(row: 1, column: 0);
                var delnew_button = Button(newframe, text: "Pay", font: ("arial", 13, "bold"), width: 13, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white", command: this.Delete_med);
                delnew_button.grid(row: 2, column: 0);
                var clr_button = Button(newframe, text: "Clear", command: this.clear_med, font: ("arial", 13, "bold"), width: 13, fg: "black", bg: "aliceblue", bd: 3, relief: RIDGE, activebackground: "black", activeforeground: "white");
                clr_button.grid(row: 3, column: 0);
                //#### scrollbar frame in right frame ####
                var side_frame = Frame(right_frame, bd: 4, relief: RIDGE, bg: "aliceblue");
                side_frame.place(x: 0, y: 160, width: 250, height: 150);
                //## scrollbar code ###
                var sc_x = ttk.Scrollbar(side_frame, orient: HORIZONTAL);
                var sc_y = ttk.Scrollbar(side_frame, orient: VERTICAL);
                this.medicine_table = ttk.Treeview(side_frame, column: ("ref", "medname"), xscrollcommand: sc_x.set, yscrollcommand: sc_y.set);
                sc_x.pack(side: BOTTOM, fill: X);
                sc_y.pack(side: RIGHT, fill: Y);
                sc_x.config(command: this.medicine_table.xview);
                sc_y.config(command: this.medicine_table.yview);
                this.medicine_table.heading("ref", text: "Ref");
                this.medicine_table.heading("medname", text: "Medicine Name");
                this.medicine_table["show"] = "headings";
                this.medicine_table.pack(fill: BOTH, expand: 1);
                this.medicine_table.column("ref", width: 100);
                this.medicine_table.column("medname", width: 100);
                this.medicine_table.bind("<ButtonRelease-1>", this.medget_cursor);
                this.fetch_datamed();
                //######## down frame #######
                var down_frame = Frame(this.root, bg: "dodgerblue4", bd: 10, relief: RIDGE);
                down_frame.place(x: 0, y: 522, width: 1350, height: 212);
                //######### scrollbar in down frame ########
                var scroll_frame = Frame(down_frame, bd: 2, relief: RIDGE, bg: "white");
                scroll_frame.place(x: 0, y: 0, width: 1330, height: 192);
                //#### scrollbar code #####
                var scroll_x = ttk.Scrollbar(scroll_frame, orient: HORIZONTAL);
                var scroll_y = ttk.Scrollbar(scroll_frame, orient: VERTICAL);
                this.info_table = ttk.Treeview(scroll_frame, column: ("ref no", "comp name", "type", "medi name", "lot no", "issue", "exp", "uses", "side effect", "warning", "dosage", "price", "product"), xscrollcommand: scroll_x.set, yscrollcommand: scroll_y.set);
                scroll_x.pack(side: BOTTOM, fill: X);
                scroll_y.pack(side: RIGHT, fill: Y);
                scroll_x.config(command: this.info_table.xview);
                scroll_y.config(command: this.info_table.yview);
                this.info_table.heading("ref no", text: "Ref No.");
                this.info_table.heading("comp name", text: "Company Name");
                this.info_table.heading("type", text: "Type Of Medicine");
                this.info_table.heading("medi name", text: "Medicine Name");
                this.info_table.heading("lot no", text: "Lot No.");
                this.info_table.heading("issue", text: "Issue Date");
                this.info_table.heading("exp", text: "Expiry Date");
                this.info_table.heading("uses", text: "Uses");
                this.info_table.heading("side effect", text: "Side Effects");
                this.info_table.heading("warning", text: "Prec & Warning");
                this.info_table.heading("dosage", text: "Dosage");
                this.info_table.heading("price", text: "Medicine Price");
                this.info_table.heading("product", text: "Product Qt.");
                this.info_table["show"] = "headings";
                this.info_table.pack(fill: BOTH, expand: 1);
                this.info_table.column("ref no", width: 100);
                this.info_table.column("comp name", width: 100);
                this.info_table.column("type", width: 100);
                this.info_table.column("medi name", width: 100);
                this.info_table.column("lot no", width: 100);
                this.info_table.column("issue", width: 100);
                this.info_table.column("exp", width: 100);
                this.info_table.column("uses", width: 100);
                this.info_table.column("side effect", width: 100);
                this.info_table.column("warning", width: 100);
                this.info_table.column("dosage", width: 100);
                this.info_table.column("price", width: 100);
                this.info_table.column("product", width: 100);
                this.info_table.bind("<ButtonRelease-1>", this.get_cursor);
                this.fetch_new();
            }
            
            //###### MEDICINE ADD FUNCTIONALITY  DECLARATION #######
            public virtual object AddMed() {
                if (this.ref_variable.get() == "" || this.addmed_variable.get() == "") {
                    messagebox.showerror("Error", "All fields are required");
                } else {
                    tk.Tk().withdraw();
                    var password = tk.simpledialog.askstring("Password", "Enter password: ", show: "*");
                    if (password != "arwa123") {
                        messagebox.showinfo("info", "Password wrong! You are not the doctor!!");
                    } else {
                        var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                        var my_cursor = conn.cursor();
                        my_cursor.execute("Insert into pharma(Ref_no,Med_name) values(?,?)", (this.ref_variable.get(), this.addmed_variable.get()));
                        conn.commit();
                        this.fetch_datamed();
                        conn.close();
                        messagebox.showinfo("Success", "MEDICINE ADDED");
                    }
                }
            }
            
            public virtual object fetch_datamed() {
                var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                var my_cursor = conn.cursor();
                my_cursor.execute("select * from pharma");
                var rows = my_cursor.fetchall();
                if (rows.Count != 0) {
                    this.medicine_table.delete(this.medicine_table.get_children());
                    foreach (var i in rows) {
                        this.medicine_table.insert("", END, values: i);
                    }
                    conn.commit();
                    conn.close();
                }
            }
            
            //##### for show data on click #####
            public virtual object medget_cursor(object @event = "") {
                var cursor_row = this.medicine_table.focus();
                var content = this.medicine_table.item(cursor_row);
                var row = content["values"];
                this.ref_variable.set(row[0]);
                this.addmed_variable.set(row[1]);
            }
            
            public virtual object Update_med() {
                if (this.ref_variable.get() == "" || this.addmed_variable.get() == "") {
                    messagebox.showerror("Error", "Ref No. and med name is required");
                } else {
                    try {
                        var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                        var my_cursor = conn.cursor();
                        my_cursor.execute("Update pharma set Med_name=? where Ref_no=?", (this.addmed_variable.get(), this.ref_variable.get()));
                        conn.commit();
                        messagebox.showinfo("Update", "Successfully Updated", parent: this.root);
                        this.fetch_datamed();
                        conn.close();
                    } catch (Exception) {
                        messagebox.showerror("Error", "Error due to:{str(e)}", parent: this.root);
                    }
                }
            }
            
            public virtual object Delete_med() {
                if (this.ref_variable.get() == "") {
                    messagebox.showerror("Error", "Ref no is required", parent: this.root);
                } else {
                    var b = Button(root, text: "Print Reciept", command: reciept);
                    b.pack(padx: 10, pady: 10);
                    pdf();
                    pdf2();
                    try {
                        var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                        var my_cursor = conn.cursor();
                        my_cursor.execute("Delete from pharma where Ref_no=? ", ValueTuple.Create(this.ref_variable.get()));
                        conn.commit();
                        messagebox.showinfo("Delete", "Successfully Deleted", parent: this.root);
                        this.fetch_datamed();
                    } catch (Exception) {
                        messagebox.showerror("Error", "Error due to:{str(e)}", parent: this.root);
                    }
                }
                Func<object> reciept = () => {
                    var top = Toplevel();
                    top.geometry("400x200");
                    top.config(background: "white");
                    var price1 = 100;
                    var qty1 = 2;
                    var total1 = price1 * qty1;
                    var l = Label(top, text: "--------Reciept-------");
                    l.pack();
                    l.config(background: "white");
                    var heading = Label(top, text: "Price\tQTY\tTOTAL");
                    heading.pack();
                    heading.config(background: "white");
                    var item1 = Label(top, text: "{price1}\t{qty1}\t{total1}");
                    item1.pack();
                    item1.config(background: "white");
                };
            }
            
            public virtual object clear_med() {
                this.ref_variable.set("");
                this.addmed_variable.set("");
            }
            
            //####### MEDICINE DEPARTMENT FUNCTIONALITY #######
            public virtual object addmedicine() {
                if (this.refno_var.get() == "" || this.lotno_var.get() == "" || this.typemed_var.get() == "") {
                    messagebox.showerror("Error", "All fields are required");
                } else {
                    var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                    var new_cursor = conn.cursor();
                    new_cursor.execute("Insert into Information(REF_NO,COMPANY_NAME,TYPE_OF_MED,MED_NAME,LOT_NO,ISSUE_DT,EXP_DT,USES,SIDE_EFFECT,PRECAUTION,DOSAGE,PRICE,QUANTITY) values(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", (this.refno_var.get(), this.companyname_var.get(), this.typemed_var.get(), this.medicine_var.get(), this.lotno_var.get(), this.issuedt_var.get(), this.expdt_var.get(), this.uses_var.get(), this.sideeffect_var.get(), this.warning_var.get(), this.dosage_var.get(), this.price_var.get(), this.quantity_var.get()));
                    conn.commit();
                    this.fetch_new();
                    messagebox.showinfo("Success", "Successfully added");
                }
            }
            
            public virtual object fetch_new() {
                var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                var new_cursor = conn.cursor();
                new_cursor.execute("select * from Information");
                var row = new_cursor.fetchall();
                if (row.Count != 0) {
                    this.info_table.delete(this.info_table.get_children());
                    foreach (var i in row) {
                        this.info_table.insert("", END, values: i);
                    }
                    conn.commit();
                }
            }
            
            public virtual object get_cursor(object @event = "") {
                var cursor_row = this.info_table.focus();
                var content = this.info_table.item(cursor_row);
                var row = content["values"];
                this.refno_var.set(row[0]);
                this.companyname_var.set(row[1]);
                this.typemed_var.set(row[2]);
                this.medicine_var.set(row[3]);
                this.lotno_var.set(row[4]);
                this.issuedt_var.set(row[5]);
                this.expdt_var.set(row[6]);
                this.uses_var.set(row[7]);
                this.sideeffect_var.set(row[8]);
                this.warning_var.set(row[9]);
                this.dosage_var.set(row[10]);
                this.price_var.set(row[11]);
                this.quantity_var.set(row[12]);
            }
            
            public virtual object update_new() {
                if (this.refno_var.get() == "" || this.lotno_var.get() == "" || this.typemed_var.get() == "") {
                    messagebox.showerror("Error", "All fields are required");
                } else {
                    var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                    var new_cursor = conn.cursor();
                    new_cursor.execute("Update Information set COMPANY_NAME=?,TYPE_OF_MED=?,MEDNAME=?,LOT_NO=?,ISSUE_DT=?,EXP_DT=?,USES=?,SIDE_EFFECT=?,PRECAUTION=?,DOSAGE=?,PRICE=?,QUANTITY=? where REF_NO=?", (this.companyname_var.get(), this.typemed_var.get(), this.medicine_var.get(), this.lotno_var.get(), this.issuedt_var.get(), this.expdt_var.get(), this.uses_var.get(), this.sideeffect_var.get(), this.warning_var.get(), this.dosage_var.get(), this.price_var.get(), this.quantity_var.get(), this.refno_var.get()));
                    conn.commit();
                    this.fetch_new();
                    this.clear_new();
                    messagebox.showinfo("Success", "Successfully updated");
                }
            }
            
            public virtual object clear_new() {
                this.refno_var.set("");
                this.companyname_var.set("");
                this.typemed_var.set("");
                this.medicine_var.set("");
                this.lotno_var.set("");
                this.issuedt_var.set("");
                this.expdt_var.set("");
                this.uses_var.set("");
                this.sideeffect_var.set("");
                this.warning_var.set("");
                this.dosage_var.set("");
                this.price_var.set("");
                this.quantity_var.set("");
            }
            
            public virtual object search_data() {
                var conn = sqlite3.connect(database: @"D:/CS/3rd/software-engineering/project/coding/Pharmacy_management-system-master/pharmacy.db");
                var new_cursor = conn.cursor();
                var selected = this.search_combo.get();
                if (selected == "Select Options") {
                    messagebox.showerror("Error", "You have to choose an option");
                } else {
                    new_cursor.execute("Select * from Information where REF_NO=?", ValueTuple.Create(this.search_txt.get()));
                    var row = new_cursor.fetchone();
                    if (row.Count != 0) {
                        this.info_table.delete(this.info_table.get_children());
                        foreach (var i in row) {
                            this.info_table.insert("", END, values: i);
                        }
                        conn.commit();
                    }
                }
            }
            
            public virtual object slider() {
                if (this.count >= this.txt.Count) {
                    this.count = -1;
                    this.text = "";
                    this.heading.config(text: this.text);
                } else {
                    this.text = this.text + this.txt[this.count];
                    this.heading.config(text: this.text);
                }
                this.count += 1;
                this.heading.after(200, this.slider);
            }
            
            public virtual object heading_color() {
                var fg = random.choice(this.color);
                this.heading.config(fg: fg);
                this.heading.after(100, this.heading_color);
            }
        }
        
        public static object root = Tk();
        
        public static object obj = Pharmacy(root);
        
        static Module() {
            root.mainloop();
        }
    }
}
