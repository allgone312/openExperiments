package classroom_management;

import java.awt.BorderLayout;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
import java.awt.event.WindowEvent;
import java.util.Iterator;
import java.util.Vector;
import javax.swing.JButton;
import javax.swing.JComboBox;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JScrollBar;
import javax.swing.JScrollPane;
import javax.swing.JTable;
import javax.swing.JTextField; 
public class ControlInterface extends JFrame implements ActionListener{
	//登录界面
	Login login;
	//主控制界面
	private JPanel 		topBar,rightBar;
	//topBar
	private JLabel 		userName;
	private JButton		quit;
	//rightBar
	private JPanel 		operationP,buttonP,searchP;
	private JLabel 		operationT,search;
	private JComboBox 	operation;
	private JButton 	searchB,alert,insert,delete;
	private JTextField	searchT;//搜索字样	 		
	//centerBar
	private	JScrollPane scroll;
	private	JTable 		content;
	private MyTableModel model;				
private String[] list=new String[]{"教师信息","教室信息","教室使用情况","教室具体使用情况"};
	private JLabel remind;
	public static void main(String[] args)
	{
		new ControlInterface();
	}
	public ControlInterface()
	{
		//登录界面 --------------------------------------------
		login=new Login(this, "登录",true);
		//登陆界面回来之后
		//topBar
		topBar		=	new JPanel();
		userName	=	new JLabel();
		userName.setText(Login.loginName);
		userName.setFont(new Font("隶书",1,25));//字体,1代表样式，字号
userName.setLocation(this.getWidth()/2-userName.getWidth()/2, userName.getHeight()/3);
		topBar.add(userName,BorderLayout.CENTER);
		quit		=	new JButton("退出");
		quit.setActionCommand("quit");
		quit.addActionListener(this);
		quit.setLocation((int) (this.getWidth()-quit.getWidth()*1.5),userName.getHeight()/3);
		topBar.add(quit,BorderLayout.EAST);
		this.add(topBar,BorderLayout.NORTH);
		//rightBar
		rightBar=new JPanel();
		rightBar.setLayout(new GridLayout(4,1));
		this.add(rightBar,BorderLayout.EAST);
		operationP=new JPanel();
		operationP.setLayout(new FlowLayout());
		operationT=new JLabel("选择表：");
		operation=new JComboBox(list);
		operation.addItemListener(new ItemListener(){
			@Override
			public void itemStateChanged(ItemEvent arg0) {
				searchT.setText("请输入"+ 
operation.getSelectedItem().toString().substring(0,2)+ "编号");
				model=new MyTableModel(operation.getSelectedItem().toString());
				content.setModel(model);
			}
		}) ;
		operationP.add(operationT);
		operationP.add(operation);
		buttonP=new JPanel();
		buttonP.setLayout(new GridLayout(3,1));
		alert=new JButton("修改");
		alert.addActionListener(this);
		alert.setActionCommand("alert");
		insert=new JButton("增加");
		insert.addActionListener(this);
		insert.setActionCommand("insert");
		delete=new JButton("删除");
		delete.addActionListener(this);
		delete.setActionCommand("delete");
		buttonP.add(alert);
		buttonP.add(insert);
		buttonP.add(delete);
		operationP.add(buttonP);
		rightBar.add(operationP);
		search=new JLabel("关键字：");
		searchT=new JTextField(10);
		searchT.setText("请输入"+operation.getSelectedItem().toString().substring(0,2)+"编号");
		searchB=new JButton("搜索");
		searchB.addActionListener(this);
		searchB.setActionCommand("search");
		searchP=new JPanel();
		searchP.setLayout(new FlowLayout());
		searchP.add(search);
		searchP.add(searchT);
		searchP.add(searchB);
		rightBar.add(searchP);
		remind=new JLabel();
		rightBar.add(remind);
		//centerBar
		model=new MyTableModel(operation.getSelectedItem().toString());
		content=new JTable(model);
		scroll=new JScrollPane(content);
		this.add(scroll,BorderLayout.CENTER);
this.setTitle("教室管理系统");
		this.setResizable(false);
		this.setLocation(180,60);
		this.setSize(1000, 600);
		this.setVisible(true);
		this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
	}
	@Override
	public void actionPerformed(ActionEvent arg0) {
		if(arg0.getActionCommand()=="quit")
		{
			System.exit(0);
		}
		if(arg0.getActionCommand()=="search")
		{
			search2UnionTable();
			return;
		}
		if(((String)operation.getSelectedItem())=="教室具体使用情况")
		{
			new RemindDialog(this, "提示",true,0);
			return;
		}
		if(arg0.getActionCommand()=="insert")
		{
			new Insert(this,"增加新数据",true,operation.getSelectedItem().toString());
			model=new MyTableModel(operation.getSelectedItem().toString());
			content.setModel(model);
			return;
		}
		if(content.getSelectedRow()==-1)
		{
			new RemindDialog(this, "提示",true,1);
			return;
		}
		if(arg0.getActionCommand()=="alert")
		{
			Vector v=(Vector)MyTableModel.rowData.get(content.getSelectedRow());
			new Update(this,"修改",true,operation.getSelectedItem().toString(),v);
			model=new MyTableModel(operation.getSelectedItem().toString());
			content.setModel(model);
			return;
		}
		if(arg0.getActionCommand()=="delete")
		{
			Vector v=(Vector) MyTableModel.rowData.get(content.getSelectedRow());
			new Delete(this,"删除",true,v,operation.getSelectedItem().toString());
			model=new MyTableModel(operation.getSelectedItem().toString());
			content.setModel(model);
			return;
		}
	}
	private void search2UnionTable()
	{
		Vector v=MyTableModel.select(operation.getSelectedItem().toString());
		Vector rowData=new Vector();
		Iterator iterator=v.iterator();
		String rNum=searchT.getText().toString().trim();
		while(iterator.hasNext())
		{
			Vector tem=(Vector)iterator.next();
			if(((String)tem.get(0)).equals(rNum))
			{
				rowData.add(tem);
			}
		}
		if(rowData.size()==0)
		{
			remind.setText("-----无该教室信息-----");
			return;
		}else
		{
			remind.setText("");
		}
		MyTableModel my=new MyTableModel(rowData,MyTableModel.columnNames);
		content.setModel(my);
	}
}
