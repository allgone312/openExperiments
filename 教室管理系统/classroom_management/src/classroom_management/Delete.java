package classroom_management;

import java.awt.FlowLayout;
import java.awt.Frame;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.util.Vector;
import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JLabel;
public class Delete extends JDialog {
	private String sql;
	public Delete(Frame arg0, String arg1, boolean arg2,final Vector v,final String name) {
		super(arg0, arg1, arg2);
		JLabel content=new JLabel("--��ʾ���� �� ɾ �� ��--");
		JButton sure=new JButton("ȷ��");
		sure.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
				if(name=="��ʦ��Ϣ")
				{
					sql="delete ClassRoomInfo where ��ʦ���='"+v.get(0).toString().trim()+"'";
					delete2Row(sql);
					System.out.println(v.get(0).toString().trim());
					sql="delete TeacherInfo where ��ʦ���='"+v.get(0).toString().trim()+"'";
					delete2Row(sql);
				}else if(name=="������Ϣ")
				{
					sql="delete ClassRoomInfo where ���ұ��='"+v.get(0).toString().trim()+"'";
					delete2Row(sql);
					sql="delete ClassInfo where ���ұ��='"+v.get(0).toString().trim()+"'";
					delete2Row(sql);
				}else if(name=="����ʹ�����")
				{
String start=v.get(1).toString().substring(0, 10)+" "
+v.get(1).toString().substring(11);
					String end=v.get(2).toString().substring(0, 10)+" "+
v.get(2).toString().substring(11);
					sql="delete ClassRoomInfo where ���ұ��='"+v.get(0).toString().trim()+"' and �Ͽο�ʼʱ��='"+start+"' and ����ʱ��='"+end+"' and ��ʦ���='"+v.get(3).toString().trim()+"'";
					delete2Row(sql);
				}
				Delete.this.dispose();
			}
		});
		JButton cancle=new JButton("ȡ��");
		cancle.addActionListener(new ActionListener(){
			@Override
			public void actionPerformed(ActionEvent e) {
				Delete.this.dispose();
			}
		});
		this.setLayout(new FlowLayout());
		this.add(content);
		this.add(sure);
		this.add(cancle);
		this.setDefaultCloseOperation(DISPOSE_ON_CLOSE);
		this.setLocation(550, 230);
		this.setSize(150,100);
		this.setVisible(true);
	}
	private void delete2Row(String sql)
	{
		Connection connection = null;
		PreparedStatement ps=null;
		try {
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
	connection=DriverManager.getConnection("jdbc:odbc:classManager", "sa", "songchao");
			ps=connection.prepareStatement(sql);
			ps.executeUpdate();
		} catch (Exception e) {
			e.printStackTrace();
		}finally{
			try {
				ps.close();
				connection.close();
			} catch (Exception e) {
				e.printStackTrace();
			}
}}}
