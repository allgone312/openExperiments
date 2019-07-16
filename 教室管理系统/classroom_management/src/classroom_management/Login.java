package classroom_management;


import java.awt.Cursor;
import java.awt.FlowLayout;
import java.awt.Frame;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowEvent;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
import javax.swing.JPanel;
import javax.swing.JPasswordField;
import javax.swing.JTextField;
public class Login extends JDialog implements ActionListener{
	private  JLabel name;
	private  JLabel psw;
	private  JTextField nameV;
	private  JPasswordField pswV;
	private  JButton login,quit;
	private  JPanel top;
	private  JPanel center;
	private  JPanel bottom;
	private  JLabel prompt;
	public static String loginName;
	public Login(Frame owner, String title, boolean modal) {
		super(owner, title, modal);
		init();
	}
	private void init()
	{
		name=new JLabel("登录名:");
		nameV=new JTextField(10);
		top=new JPanel();
		top.add(name);
		top.add(nameV);
		this.add(top);
		psw=new JLabel("密    码:");
		pswV=new JPasswordField(10);
		center=new JPanel();
		center.add(psw);
		center.add(pswV);
		this.add(center);
		login=new JButton();
		login.setText("登录");
		login.setActionCommand("login");
		login.addActionListener(this);
		quit=new JButton("退出");
		quit.setActionCommand("quit");
		quit.addActionListener(this);
		bottom=new JPanel();
		bottom.add(login);
		bottom.add(quit);
		this.add(bottom);
		prompt=new JLabel();
		this.add(prompt);
		this.setLayout(new GridLayout(4, 1));
		this.setLocation(550, 230);
		this.setSize(200,200);
		this.setVisible(true);
	}
	@Override
	public void actionPerformed(ActionEvent arg0) {
		if(arg0.getActionCommand()=="login")
		{
			String name=nameV.getText();
			String psw=pswV.getText();
			if(name.length()<=0||psw.length()<=0)
			{
				prompt.setText("提示：用户名或密码为空！");
				return;
			}
			if(checkCount(name,psw))
			{
				this.dispose();
			}else
			{
				prompt.setText("提示：用户名或密码错误！");
				return;
			}
		}else if(arg0.getActionCommand()=="quit")
		{
			System.exit(0);
		}
	}
	private boolean checkCount(String name,String psw)
	{
		Connection connection=null;
		PreparedStatement ps=null;
		ResultSet rs=null;
		try {
			//加载驱动
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
			//得到连接
			connection=DriverManager.getConnection("jdbc:odbc:classManager", "sa", "songchao");
			//创建访问数据库接口
			ps=connection.prepareStatement("select * from manager");
			rs=ps.executeQuery();
			while(rs.next())
			{
				String namet=rs.getString(1);
				String pswt=rs.getString(2);
				System.out.println(namet+"<>"+pswt+"-------"+name+"<>"+psw+"---");
				if(namet.equals(name)&&pswt.equals(psw))
				{
					loginName=namet;
					return true;
				}
			}
			System.out.println("false");
		} catch (Exception e) {
			e.printStackTrace();
		}finally{
			try {
				rs.close();
				ps.close();
				connection.close();
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		return false;
	}
	@Override
	protected void processWindowEvent(WindowEvent arg0) {
		super.processWindowEvent(arg0);
		if(arg0.getID()==WindowEvent.WINDOW_CLOSING)
		{
			System.exit(0);
		}
	}
}






