package classroom_management;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Vector;
import javax.swing.table.AbstractTableModel;
public class MyTableModel extends AbstractTableModel{
	public static Vector 	rowData;
	public static Vector 		columnNames;
	public MyTableModel(String value) {
		select(value);
	}
public MyTableModel(Vector rowData,Vector columnNames) {
		this.rowData=rowData;
		this.columnNames=columnNames;
	}
	public static Vector select(String value)
	{
		rowData=new Vector();
		columnNames=new Vector();
		Connection connection=null;
		PreparedStatement ps=null;
		ResultSet rs=null;
		String sql = null;
		if(value=="��ʦ��Ϣ")
		{
			columnNames.add("��ʦ���");
			columnNames.add("��ʦ����");
			columnNames.add("���ڿγ�");
			columnNames.add("��ʦְ��");
			sql="select * from TeacherInfo";
		}else if(value=="������Ϣ")
		{
			columnNames.add("���ұ��");
			columnNames.add("�����豸");
			columnNames.add("������������");
			columnNames.add("���ҹ���Ա���");
			sql="select * from ClassInfo";
		}else if(value=="����ʹ�����")
		{
			columnNames.add("���ұ��");
			columnNames.add("�Ͽο�ʼʱ��");
			columnNames.add("����ʱ��");
			columnNames.add("��ʦ���");
			sql="select ���ұ��, convert(varchar(20),�Ͽο�ʼʱ��,111),convert(varchar(20),�Ͽο�ʼʱ��,108),convert(varchar(20),����ʱ��,111) ,convert(varchar(20),����ʱ��,108), ��ʦ��� from ClassRoomInfo";
		}
		else if(value=="���Ҿ���ʹ�����")
		{
			columnNames.add("���ұ��");
			columnNames.add("��ʦ���");
			columnNames.add("��ʦ����");
			columnNames.add("���ڿγ�");
			columnNames.add("�Ͽο�ʼʱ��"); 
			columnNames.add("����ʱ��");
			columnNames.add("��ʦְ��");
			columnNames.add("�����豸");
			columnNames.add("������������");
			columnNames.add("���ҹ���Ա���");
			sql="select ClassInfo.���ұ��,TeacherInfo.��ʦ���,TeacherInfo.��ʦ����,TeacherInfo.���ڿγ�, convert(varchar(20),ClassRoomInfo.�Ͽο�ʼʱ��,111),convert(varchar(20),ClassRoomInfo.�Ͽο�ʼʱ��,108),convert(varchar(20),ClassRoomInfo.����ʱ��,111) ,convert(varchar(20),ClassRoomInfo.����ʱ��,108) ,TeacherInfo.��ʦְ��,ClassInfo.�����豸,ClassInfo.������������,ClassInfo.���ҹ���Ա��� from ClassRoomInfo,TeacherInfo,ClassInfo  where ClassInfo.���ұ��= ClassRoomInfo.���ұ��   and  TeacherInfo.��ʦ���=ClassRoomInfo.��ʦ���";
		}
		try {
			//��������
			Class.forName("sun.jdbc.odbc.JdbcOdbcDriver");
			//�õ�����
	        connection=DriverManager.getConnection("jdbc:odbc:classManager", "sa", "songchao");
			//�����������ݿ�ӿ�
			ps=connection.prepareStatement(sql);
			rs=ps.executeQuery();
			if(value=="��ʦ��Ϣ")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getString(3));
					tem.add(rs.getString(4));
					rowData.add(tem);
				}
			}else if(value=="������Ϣ")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getInt(3));
					tem.add(rs.getString(4));
					rowData.add(tem);
				}
			}else if(value=="����ʹ�����")
			{
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2)+"/"+rs.getString(3));
					tem.add(rs.getString(4)+"/"+rs.getString(5));
					tem.add(rs.getString(6));
					rowData.add(tem);
				}
			}else if(value=="���Ҿ���ʹ�����"){
				while(rs.next())
				{
					Vector tem=new Vector();
					tem.add(rs.getString(1));
					tem.add(rs.getString(2));
					tem.add(rs.getString(3));
					tem.add(rs.getString(4));
					tem.add(rs.getString(5)+"/"+rs.getString(6));
					tem.add(rs.getString(7)+"/"+rs.getString(8));
					tem.add(rs.getString(9));
					tem.add(rs.getString(10));
					tem.add(rs.getInt(11));
					tem.add(rs.getString(12));
					rowData.add(tem);
				}
			}
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
		return rowData;
	}
	@Override
	public String getColumnName(int arg0) {
		return (String) columnNames.get(arg0);
	}
	@Override
	public int getColumnCount() {
		return columnNames.size();
	}
	@Override
	public int getRowCount() {
		return rowData.size();
	}	
@Override 
	public Object getValueAt(int rowIndex, int columnIndex) {
		return ((Vector)rowData.get(rowIndex)).get(columnIndex);
	}
}